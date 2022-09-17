using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class AdapterPatternExercise5 : MonoBehaviour
    {
        private void Start()
        {
            VietnameseTarget client = new TranslatorAdapter(new JapaneseAdaptee());
            client.send("Xin chào");
        }

        public interface VietnameseTarget
        {
            void send(string words);
        }

        public class JapaneseAdaptee
        {
            public void receive(string words)
            {
                Debug.Log("Retrieving words from Adapter ...: " + words);
            }
        }

        public class TranslatorAdapter : VietnameseTarget
        {
            private JapaneseAdaptee adaptee;

            public TranslatorAdapter(JapaneseAdaptee adaptee)
            {
                this.adaptee = adaptee;
            }
            public void send(string words)
            {
                Debug.Log("Reading Words ..." + words);
                string vietnameseWords = this.translate(words);
                Debug.Log("Sending Words ...");
                adaptee.receive(vietnameseWords);
            }

            private string translate(string vietnameseWords)
            {
                Debug.Log("Translated!");
                return "こんにちは";
            }
        }
    }
}