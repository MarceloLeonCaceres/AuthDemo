﻿namespace Models
{
    public static class ModelConst
    {
        public const int MAX_DEPTNAME_LENGTH = 150;
        public const string ERROR_MSG_MAX_DEPTNAME_LENGTH = "El nombre del departamento no puede superar los 150 caracteres";

        public const int MIN_SSN_LENGTH = 9;
        public const int MAX_SSN_LENGTH = 10;
        public const string ERROR_MSG_MAX_SSN_LENGTH = "La cédula puede tener un máximo de 10 caracteres";
        public const string ERROR_MSG_MIN_SSN_LENGTH = "La cédula puede tener un mínimo de 9 caracteres";

        public const int MAX_BADGENUMBER_LENGTH = 9;
        public const string ERROR_MSG_MAX_BADGENUMBER_LENGTH = $"El código del empleado puede tener un máximo de 9 caracteres";
    }
}
