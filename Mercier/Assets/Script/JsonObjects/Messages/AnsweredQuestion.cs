﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AnsweredQuestion : SocketMessage
{
    public string answer;

    public AnsweredQuestion(int playerId, string answer) : base(playerId)
    {
        messageType = MessageType.ANSWERED_QUESTION;
        this.answer = answer;
    }
}
