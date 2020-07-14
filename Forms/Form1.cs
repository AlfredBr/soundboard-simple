using SoundBoard.Properties;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio.CoreAudioApi;
using NAudio.Wave;

#pragma warning disable CS0164

namespace SoundBoard
{
    public partial class SoundboardForm : Form
    {
        private Dictionary<int, string> _ttsSettings;
        private Dictionary<int, string> _mp3Settings;
        private string _iniFile;
        public SoundboardForm()
        {
            InitializeComponent();

            _ttsSettings = new Dictionary<int, string>();
            _mp3Settings = new Dictionary<int, string>();

            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            _iniFile = $"{assemblyName}.ini";
        }
        public void SaveSetting(Control control)
        {
            Debug.WriteLine("SaveSetting");
            if (control is TtsControl)
            {
                var ctl = control as TtsControl;
                _ttsSettings.Remove(ctl.Index);
                _ttsSettings.Add(ctl.Index, ctl.Setting.Trim());
            }
            if (control is Mp3Control)
            {
                var ctl = control as Mp3Control;
                _mp3Settings.Remove(ctl.Index);
                _mp3Settings.Add(ctl.Index, ctl.Setting.Trim());
            }
        }

        private void EnumerateInputDevices()
        {
            Console.WriteLine("EnumerateInputDevices");
            //create enumerator
            var enumerator = new MMDeviceEnumerator();
            //cycle through all audio capture devices
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                Console.WriteLine($"<== {i} {enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)[i]}");
            }
            //clean up
            enumerator.Dispose();
        }

        private int _waveOutDeviceNumber;
        public int GetWaveOutDeviceNumber()
        {
            return _waveOutDeviceNumber;
        }

        private void EnumerateOutputDevices()
        {
            Console.WriteLine("EnumerateOutputDevices");
            //create enumerator
            var enumerator = new MMDeviceEnumerator();
            //cycle trough all audio render devices
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                Console.WriteLine($"==> {i} {enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)[i]}");
            }
            //clean up
            enumerator.Dispose();


            Console.WriteLine("DirectSoundOut");
            foreach (var dev in DirectSoundOut.Devices)
            {
                Console.WriteLine($"{dev.Guid} {dev.ModuleName} {dev.Description}");
            }
        }

        private void OutputDeviceSelectors()
        {
            _comboBoxWaveOut.Items.Clear();

            using (var enumerator = new MMDeviceEnumerator())
            {
                for (int i = 0; i < WaveOut.DeviceCount; i++)
                {
                    var name = $"{enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)[i]}";
                    var value = i;

                    _comboBoxWaveOut.DisplayMember = "Name";
                    _comboBoxWaveOut.Items.Add(new { Name = name, Value = value });
                    _comboBoxWaveOut.SelectedIndex = 0;
                    _comboBoxWaveOut.SelectedIndexChanged += (o, e) => _waveOutDeviceNumber = ((dynamic)_comboBoxWaveOut.SelectedItem).Value;
                }
            }
        }
        private void OnFormLoad(object sender, EventArgs e)
        {
            var tabIndex = 0;
            var numberOfControls = 16;

            //EnumerateInputDevices();
            //EnumerateOutputDevices();
            OutputDeviceSelectors();

            if (File.Exists(_iniFile))
            {
                var iniData = File.ReadAllLines(_iniFile);
                foreach (var line in iniData)
                {
                    var parts = line.Split('\t');
                    var section = parts[0];
                    var index = Convert.ToInt32(parts[1]);
                    var txt = parts[2];

                    if (section == "TTS")
                    {
                        _ttsSettings.Add(index, txt);
                    }

                    if (section == "MP3")
                    {
                        _mp3Settings.Add(index, txt);
                    }
                }
            }

        Tts:
            {
                _ttsPanel.Controls.Clear();
                var controls = new List<Control>();
                for (int x = 0; x < numberOfControls; x++)
                {
                    var txt = _ttsSettings.ContainsKey(x) ? _ttsSettings[x] : "";
                    var control = new TtsControl(x, txt);
                    control.Dock = DockStyle.Top;
                    control.TabIndex = tabIndex++;
                    controls.Add(control);
                }
                controls.Reverse();
                _ttsPanel.Controls.AddRange(controls.ToArray());
                _ttsPanel.VerticalScroll.Value = 0;
            }

        Mp3:
            {
                _mp3Panel.Controls.Clear();
                var controls = new List<Control>();
                for (int x = 0; x < numberOfControls; x++)
                {
                    var txt = _mp3Settings.ContainsKey(x) ? _mp3Settings[x] : "";
                    var control = new Mp3Control(x, txt);
                    control.Dock = DockStyle.Top;
                    control.TabIndex = tabIndex++;
                    controls.Add(control);
                }
                controls.Reverse();
                _mp3Panel.Controls.AddRange(controls.ToArray());
                _mp3Panel.VerticalScroll.Value = 0;
            }
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TtsControl ctl in _ttsPanel.Controls)
            {
                SaveSetting(ctl);
            }
            foreach (Mp3Control ctl in _mp3Panel.Controls)
            {
                SaveSetting(ctl);
            }

            var stringbuilder = new StringBuilder();
            foreach (var key in _ttsSettings.Keys.OrderBy(t => t))
            {
                var val = _ttsSettings[key];
                stringbuilder.AppendLine($"TTS\t{key}\t{val}");
            }
            foreach (var key in _mp3Settings.Keys.OrderBy(t => t))
            {
                var val = _mp3Settings[key];
                stringbuilder.AppendLine($"MP3\t{key}\t{val}");
            }
            File.WriteAllText(_iniFile, stringbuilder.ToString());
        }
    }
}
