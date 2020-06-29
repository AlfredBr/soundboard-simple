using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using System.Threading;
using System.Diagnostics;

namespace SoundBoard
{
    public partial class Mp3Control : UserControl
    {
        public int Index { get; set; }
        public string Setting => _textBox.Text;
        public Mp3Control()
        {
            InitializeComponent();
        }
        public Mp3Control(int x, string txt) : this()
        {
            Index = x;
            _n.Text = (x+1).ToString();
            _textBox.Text = txt;
        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            _button.Enabled = false;
            Play(_textBox.Text, () => { _button.Invoke(new MethodInvoker(() => { _button.Enabled = true; })); });
        }
        private void Play(string filename, Action callback = null)
        { 
            if (string.IsNullOrEmpty(filename)) { callback?.Invoke(); return; }
            if (!File.Exists(filename)) { callback?.Invoke(); return; }
            if (Path.GetExtension(filename)?.ToLower() != ".mp3") { callback?.Invoke(); return; }

            Task.Run(() =>
            {
                using (var stream = new FileStream(filename, FileMode.Open))
                using (WaveStream blockAlignedStream =
                                    new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(
                                        new Mp3FileReader(stream))))
                {
                    var autoResetEvent = new AutoResetEvent(false);
                    var waveOut = new WaveOutEvent();
                    waveOut.Init(blockAlignedStream);
                    waveOut.PlaybackStopped += (_, o) =>
                    {
                        Debug.WriteLine("nAudio: Stopped Playing");
                        autoResetEvent.Set();
                    };
                    Debug.WriteLine($"nAudio: Playing '{filename}'");
                    waveOut.Play();
                    autoResetEvent.WaitOne();
                    Debug.WriteLine("nAudio: Exited");
                    callback?.Invoke();
                }
            });
        }
        private void OnOpenFileClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _textBox.Text = ofd.FileName;
            }
        }
    }
}
