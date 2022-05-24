﻿namespace Chat_App.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        // true or false
        public Boolean Sent { get; set; }
       
    }
}
