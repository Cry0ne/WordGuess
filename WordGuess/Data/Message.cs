using System.Collections.Generic;

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
        }
        public string TextMessage
        {
            get
            {
                return textMessage;
            }
        }

        public void Add(string poster, string text)
        {
            posterMessage = poster;
            textMessage = text;
        }     
    }
}
