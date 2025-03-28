using Moq;
using NUnit.Framework;

namespace PredictionEngine.Tests
{
    public class PredictionEngineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("", "")]
        [TestCase("Hello how are you", "you")]
        [TestCase("Hello", "Hello")]
        public void ShouldCallMonogramWhenPartialWordIsGive(string phrase, string lastword)
        {
            var mockAlgo = new Mock<ILanguageModelAlgo>();
            PredictEngine predictionEngine = new PredictEngine(mockAlgo.Object);

            var prediction = predictionEngine.Predict(phrase);

            mockAlgo.Verify(p => p.predictUsingMonogram(lastword), Times.Once());
        }


        [TestCase(" ", "")]
        [TestCase("Hello how are you ", "you")]
        [TestCase("Hello ", "Hello")]
        public void ShouldCallBiogramWhenPhraseEndsWithASpace(string phrase, string lastWord)
        {
            //Arrange
            var mockAlgo = new Mock<ILanguageModelAlgo>();
            PredictEngine predictionAgent = new PredictEngine(mockAlgo.Object);

            //Act
            string prediction = predictionAgent.Predict(phrase);

            //Assert
            mockAlgo.Verify(p => p.predictUsingBigram(lastWord), Times.Once());
        }


    }
}