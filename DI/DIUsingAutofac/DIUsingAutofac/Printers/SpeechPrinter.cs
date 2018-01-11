
namespace DIUsingAutofac
{
    using System;
    using System.Speech.Synthesis;

    public class SpeechPrinter : IPrinter
    {
        public string GetName => GetType().Name;

        public void Print(string content)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak(content);
        }
    }
}
