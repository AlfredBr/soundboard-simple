using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;

namespace SoundBoard
{
    public partial class TtsControl : UserControl
    {
        public int Index { get; set; }
        public string Setting => _textBox.Text;

        public TtsControl()
        {
            InitializeComponent();
        }
        public TtsControl(int x, string txt) : this()
        {
            Index = x;
            _n.Text = (x + 1).ToString();
            _textBox.Text = txt;
        }

        private class Voice
        {
            public string Name { get; set; }
            public InstalledVoice Value { get; set; }
        }

        protected override void OnLoad(EventArgs e)
        {
            using (var speechSynthesizer = new SpeechSynthesizer())
            {
                _comboBox.Items.Clear();
                var installedVoices = speechSynthesizer.GetInstalledVoices();
                foreach (InstalledVoice voice in installedVoices)
                {
                    _comboBox.Items.Add(new Voice
                    {
                        Name = $"{voice.VoiceInfo.Gender}".Substring(0, 1),
                        Value = voice
                    });
                }
                _comboBox.DisplayMember = "Name";
                _comboBox.SelectedIndex = 0;
            }

            base.OnLoad(e);
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            _button.Enabled = false;
            Speak(_textBox.Text, () => { _button.Invoke(new MethodInvoker(() => { _button.Enabled = true; })); });
        }

        private void Speak(string textToSpeak, Action callback = null)
        {
            if (string.IsNullOrEmpty(textToSpeak)) { callback?.Invoke(); return; }
            
            try
            {
                Voice voice = _comboBox.SelectedItem as Voice;
                Task.Run(
                    () =>
                    {
                        using (var speechSynthesizer = new SpeechSynthesizer())
                        {
                            speechSynthesizer.SelectVoice(voice.Value.VoiceInfo.Name);
                            var stream = new MemoryStream();
                            speechSynthesizer.SetOutputToWaveStream(stream);
                            speechSynthesizer.Speak(textToSpeak);
                            stream.Position = 0;

                            using (WaveStream blockAlignedStream = 
                                new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(
                                    new WaveFileReader(stream))))
                            {
                                var autoResetEvent = new AutoResetEvent(false);
                                var waveOut = new WaveOutEvent();
                                waveOut.Init(blockAlignedStream);
                                waveOut.PlaybackStopped += (e,o) => { 
                                    Debug.WriteLine("nAudio: Stopped Speaking");
                                    autoResetEvent.Set();
                                };
                                Debug.WriteLine($"nAudio: Saying '{textToSpeak}'");
                                waveOut.Play();
                                autoResetEvent.WaitOne();
                                callback?.Invoke();
                                Debug.WriteLine("nAudio: Exited");
                            }
                        }
                    });
            }
            catch
            {
                // nop
            }
        }
    }
}
