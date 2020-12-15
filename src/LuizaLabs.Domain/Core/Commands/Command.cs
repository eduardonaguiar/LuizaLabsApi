﻿using FluentValidation.Results;
using LuizaLabs.Domain.Core.Events;
using System;


namespace LuizaLabs.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}