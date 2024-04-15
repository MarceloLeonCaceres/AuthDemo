namespace Models
{
    public static class ModelConst
    {
        // Department
        public const int MAX_DEPTNAME_LENGTH = 150;
        public const string ERROR_MSG_MAX_DEPTNAME_LENGTH = "El nombre del departamento no puede superar los 150 caracteres";

        //Userinfo
        public const int MIN_SSN_LENGTH = 9;
        public const int MAX_SSN_LENGTH = 10;
        public const string ERROR_MSG_MAX_SSN_LENGTH = "La cédula puede tener un máximo de 10 caracteres";
        public const string ERROR_MSG_MIN_SSN_LENGTH = "La cédula puede tener un mínimo de 9 caracteres";

        public const int MAX_BADGENUMBER_LENGTH = 9;
        public const string ERROR_MSG_MAX_BADGENUMBER_LENGTH = $"El código del empleado puede tener un máximo de 9 caracteres";

        public const int MAX_NAME_LENGTH = 15;
        public const string ERROR_MSG_MAX_NAME_LENGTH = "El nombre del empleado puedetener un máximo de 150 caracteres";

        // AppAdmin
        public const int MIN_USERNAME_LENGTH = 8;
        public const string ERROR_MSG_MIN_USERNAME_LENGTH = "El nombre del admin debe tener mínimo 8 caracteres, máximo 20, y debe tener al menos una letra mayúscula, una letra minúscula y un dígito";

        public const int MIN_PASSWORD_LENGTH = 8;
        public const int MAX_PASSWORD_LENGTH = 20;
        public const string ERROR_MSG_PASSWORD = "El password debe tener mínimo 8 caracteres, máximo 20, y debe tener al menos una letra mayúscula, una letra minúscula y un dígito";
        
    }
}
