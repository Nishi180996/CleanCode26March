using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictionEngine
{
    public class PredictEngine
    {
        private ILanguageModelAlgo languageModelAlgo;

        public PredictEngine(ILanguageModelAlgo algo)
        {
            this.languageModelAlgo = algo;
        }

        public string Predict(string phrase)
        {
            string lastWord = getLastWord(phrase);
            if (phrase.EndsWith(" "))
            {
                return languageModelAlgo.predictUsingBigram(lastWord);

            }
            else
            {
                return languageModelAlgo.predictUsingMonogram(lastWord);
            }
        }

        private string getLastWord(string phrase)
        {
            string[] words = phrase.Trim().Split(" ");
            string lastWord = words[words.Length - 1];
            return lastWord;
        }
    }
}