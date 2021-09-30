using System;

namespace WordGuess.Data
{
    public class Message
    {
        private string posterMessage;
        private string textMessage;

        public string Poster
        {
            get
            {
                return posterMessage;
            }
            set
            {
                posterMessage = !String.IsNullOrEmpty(value) ? value : "Система";
            }
        }
        public string TextMessage
        {
            get
            {
                return textMessage;
            }
            set
            {
                textMessage = !String.IsNullOrEmpty(value) ? value : "Введите слово";
            }
        }
    }
}
