﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LiteFx.DomainResult
{
	public class ErrorResult : IDomainResult
	{
		List<ValidationResult> messages;
		public IEnumerable<ValidationResult> Messages
		{
			get
			{
				return messages.AsEnumerable();
			}
		}

		public ErrorResult()
		{
			messages = new List<ValidationResult>();
		}

		public ErrorResult(string message)
			: this()
		{
			AddMessage(message);
		}

		public ErrorResult(string key, string message)
			: this()
		{
			AddMessage(key, message);
		}

		public ErrorResult AddMessage(string key, string message)
		{
			messages.Add(new ValidationResult(message, new string[] { key }));
			return this;
		}

		public ErrorResult AddMessage(string message)
		{
			messages.Add(new ValidationResult(message));
			return this;
		}

		public ErrorResult AddMessageIf(string key, string message, Func<bool> lambda)
		{
			if (lambda())
				messages.Add(new ValidationResult(message, new string[] { key }));
			return this;
		}

		public ErrorResult AddMessageIf(string message, Func<bool> lambda)
		{
			if (lambda())
				messages.Add(new ValidationResult(message));
			return this;
		}

		public override bool Equals(object obj)
		{
			var newObj = obj as ErrorResult;
			if (newObj == null)
				return false;

			if (ReferenceEquals(this, obj))
				return true;

			if (Messages.Count() != newObj.Messages.Count())
				return false;

			for (var i = 0; i < Messages.Count(); i++)
			{
				var elementDest = newObj.Messages.ElementAt(i);
				var elementSource = Messages.ElementAt(i);

				if (!elementSource.ErrorMessage.Equals(elementDest.ErrorMessage))
					return false;

				if (elementDest.MemberNames.Count() != elementSource.MemberNames.Count())
					return false;

				for (var j = 0; j < elementDest.MemberNames.Count(); j++)
				{
					if (!elementDest.MemberNames.ElementAt(j).Equals(elementSource.MemberNames.ElementAt(j)))
						return false;
				}
			}

			return true;
		}
	}

	public class ErrorResult<T> : ErrorResult, IDomainResult<T>
	{
		private T body;
		public T Body
		{
			get { return body; }
		}

		public ErrorResult(T body)
		{
			this.body = body;
		}

		public ErrorResult(T body, string key, string message)
			: base(key, message)
		{
			this.body = body;
		}

		public ErrorResult(T body, string message)
			: base(message)
		{
			this.body = body;
		}

		public override bool Equals(object obj)
		{
			var newObj = obj as ErrorResult<T>;
			if (newObj == null)
				return false;

			return ReferenceEquals(this, obj) || base.Equals(obj);
		}
	}
}