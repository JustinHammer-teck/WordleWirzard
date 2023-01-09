namespace WordGuess.Web.Services;

public class WordScoringService
{
    public IEnumerable<(string, double)> WordScore(IEnumerable<string> possibleWord,
        IEnumerable<(char, int[])> letterFeq)
    {
        var wordValue = new List<(string, double)>();
        int[] maxFeq = { 0, 0, 0, 0, 0 };
        foreach (var c in letterFeq)
        {
            for (int i = 0; i < 5; i++)
            {
                if (maxFeq[i] < c.Item2[i])
                {
                    maxFeq[i] = c.Item2[i];
                }
            }
        }

        foreach (var word in possibleWord)
        {
            var worRef = word.ToLower();
            double score = 1;
            for (var i = 0; i < 5; i++)
            {
                var letter = worRef[i];
                var index = letterFeq
                    .ToList()
                    .Find(x => x.Item1 == letter);
                score *= 1 + Math.Pow((index.Item2[i] - maxFeq[i]), 2);
            }

            wordValue.Add((word, score));
        }

        return wordValue;
    }

    public string BestWord(string[] possibleWord, IEnumerable<(char, int[])> letterFeq)
    {
        double maxScore = 9999999999999999999;
        var result = "";
        var score = WordScore(possibleWord, letterFeq);

        foreach (var word in possibleWord)
        {
            var index = score.ToList().Find(x => x.Item1 == word);
            if (index.Item2 < maxScore)
            {
                maxScore = index.Item2;
                result = word;
            }
        }

        return result;
    }

    public IEnumerable<(char, int[])> LetterFeq(IEnumerable<string> possibleWords)
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        var letterfeq = new List<(char, int[])>();
        foreach (var c in alphabet)
        {
            int[] feq = { 0, 0, 0, 0, 0 };
            for (int i = 0; i < 5; i++)
            {
                foreach (var word in possibleWords)
                {
                    if (word[i] == c)
                    {
                        feq[i] += 1;
                    }
                }
            }

            letterfeq.Add((c, feq));
        }

        return letterfeq;
    }
}