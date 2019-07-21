using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Physio.Web.Exceptions
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base("Forbidden transaction")
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }
    }

    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException() : base("UnAuthorized transaction")
        {
        }

        public UnAuthorizedException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException() : base("Record Not Founded")
        {
        }

        public RecordNotFoundException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class NullObjectException : Exception
    {
        public NullObjectException() : base("null value passed")
        {
        }

        public NullObjectException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class BlobExteption : Exception
    {
        public BlobExteption() : base("null value passed")
        {
        }

        public BlobExteption(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class InvalidDomainCastException : Exception
    {
        public InvalidDomainCastException() : base("Invalid domain cast")
        {
        }

        public InvalidDomainCastException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class EntityValidationException : Exception
    {
        public EntityValidationException() : base("validation faild")
        {
        }

        public EntityValidationException(string message) : base(message)
        {
        }

        public EntityValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    [Serializable]
    public class PrimaryKeyViolationException : Exception
    {
        public PrimaryKeyViolationException() : base("already exists")
        {
        }

        public PrimaryKeyViolationException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class OperationFailedException : Exception
    {
        public OperationFailedException() : base("already exists")
        {
        }

        public OperationFailedException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class ForeignKeyViolationException : Exception
    {
        public ForeignKeyViolationException() : base("FK exist")
        {
        }

        public ForeignKeyViolationException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class PermissionException : Exception
    {
        public PermissionException() : base("Access denied.please contact super admin")
        {
        }

        public PermissionException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class SameNameException : Exception
    {
        public SameNameException() : base("this name is already exsist")
        {
        }

        public SameNameException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class InvalidProcessException : Exception
    {
        public InvalidProcessException() : base("cannot do this")
        {
        }

        public InvalidProcessException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class InvalidDataException : Exception
    {
        public InvalidDataException() : base("invalied data")
        {
        }

        public InvalidDataException(string message) : base(message)
        {
        }
    }



    [Serializable]
    public class MySqlException : Exception
    {
        public MySqlException() : base("Model Error")
        {
        }

        public MySqlException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class EmailNotSendException : Exception
    {
        public EmailNotSendException() : base("There are no matching members to send emails")
        {
        }

        public EmailNotSendException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class DataInconsistencyException : Exception
    {
        public DataInconsistencyException() : base("Data Inconsistency")
        {
        }

        public DataInconsistencyException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class DataInconsistencyClientException : Exception
    {
        public DataInconsistencyClientException() : base("Data Inconsistency")
        {
        }

        public DataInconsistencyClientException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class PaymentGatewayException : Exception
    {
        public PaymentGatewayException() : base("PaymentGatewayException")
        {
        }

        public PaymentGatewayException(string message) : base(message)
        {
        }
    }

    [Serializable]
    public class EatException : Exception
    {
        public EatException() : base("EatException")
        {
        }

        public EatException(Exception e) : base(e.Message)
        {
        }

        public EatException(string message) : base(message)
        {
        }
    }


    }
