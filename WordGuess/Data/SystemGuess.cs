using System;

namespace WordGuess.Data
{
    public class SystemGuess
    {

        readonly Random random;
        private string secretWord = "";
        private int countOfCheck = 0;
        public string SecretWord { get { return secretWord; }}

        private string[] words = new string[]{ 
            "яблоко",
            "сведения",
            "дуло",
            "цель",
            "лопата",
            "пирамида",
            "дискотека",
            "абонемент",
            "ирис",
            "роза",
            "мир",
            "казус",
            "свекла",
            "оазис",
            "клюв",
            "искра",
            "напев",
            "жребий",
            "обломок", 
            "рубашка" 
        };

        public SystemGuess()
        {
            random = new Random(DateTime.Now.Millisecond);
            secretWord = words[random.Next(0,words.Length)];
        }

        public string Check(string userWord)
        {
            countOfCheck++;
            if (userWord.Length == secretWord.Length)
            {
                if (string.Equals(userWord, secretWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    countOfCheck = 0;
                    secretWord = words[random.Next(0, words.Length)];
                    return "Вы угадали! Иии слово загаданно заново!";
                }
                else
                {
                    return GetPrompt(userWord);
                }
            }
            else
            {
                if (countOfCheck > 3)
                {
                    if (countOfCheck < 8)
                        return userWord.Length > secretWord.Length ? "Загаданное слово короче" : "Загаданное слово длинее";

                    else
                        return userWord.Length > secretWord.Length ? $"Загаданное слово короче... на{userWord.Length - secretWord.Length}." : $"Загаданное слово длинее на... {secretWord.Length - userWord.Length}.";
                }
                else
                    return "Не угадал."; 
            }  

        }

        private string GetPrompt(string userWord)
        {
            string prompt = "";
            if (countOfCheck > 3) 
            {
                if (userWord[0] != SecretWord[0])
                {
                    prompt = $"Первая буква '{SecretWord[0]}'!";
                }
                else if (userWord[userWord.Length - 1] != SecretWord[SecretWord.Length - 1])
                {
                    prompt = $"Последняя буква '{SecretWord[SecretWord.Length - 1]}'!";
                }
                else if(userWord[0] == SecretWord[0] && userWord.Length - 1 == SecretWord.Length - 1) 
                {
                    for (int i = 1; i < SecretWord.Length - 1; i++)
                    {
                        if (userWord[i] != SecretWord[i])
                        {
                            prompt = $"На позиции {i + 1} нахоодится буква '{SecretWord[i]}'.";
                        }
                    }
                }

                switch (random.Next(0,3))
                {
                    case 0:
                        prompt += $" Это уже {countOfCheck}-я попытка. Можно было и быстрее.";
                        break;

                    case 1:
                        prompt += $" Спустя {random.Next(2, 365)} дня(й), мы всё ещё гадаем.";                   
                        break;

                    case 2:
                        prompt += $" Шучу.... А может и нет.";            
                        break;
                }
            }
            
            return prompt;
        }


    }
}
