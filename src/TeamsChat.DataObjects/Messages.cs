﻿using System;

namespace TeamsChat.DataObjects
{
    public class Messages : Entity
    {
        public string Text { get; set; }
        public DateTime SentAt { get; set; }
    }
}