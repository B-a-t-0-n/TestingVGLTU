namespace TestingVGLTU.SharedKernel;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            var label = name ?? "значение";
            return Error.Validation("value.is.invalid", $"{label} некорректно");
        }

        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" для Id '{id}'";
            return Error.Validation("record.not.found", $"запись не найдена{forId}");
        }

        public static Error ValueIsRequired(string? name = null)
        {
            var label = name == null ? "" : " " + name + " ";
            return Error.Validation("length.is.invalid", $"некорректная длина{label}");
        }

        public static Error AlreadyExist()
        {
            return Error.Validation("record.already.exist", "запись уже существует");
        }

        public static Error NotFound(string? name)
        {
            var label = name == null ? "" : " " + name + " ";
            return Error.Validation("record.not.found", $"запись не найдена{label}");
        }

        public static Error Timeout(string? description = null)
        {
            var label = description == null ? "" : " " + description + " ";
            return Error.Validation("request.timeout", $"превышено время ожидания{label}");
        }
    }

    public static class User
    {
        public static Error InvalidCredentials()
        {
            return Error.Validation("credentials.is.invalid", "неверные учетные данные");
        }
    }

    public static class Tokens
    {
        public static Error ExpiredToken()
        {
            return Error.Validation("token.is.expired", "токен истёк");
        }

        public static Error InvalidToken()
        {
            return Error.Validation("token.is.invalid", "токен некорректен");
        }
    }

    public static class Testing
    {
        public static Error TestingCompleted()
        {
            return Error.Validation("testing.completed", "тестирование завершено");
        }

        public static Error AttemptsEnded()
        {
            return Error.Validation("testing.attempts.ended", "попытки закончились");
        }
    }
}
