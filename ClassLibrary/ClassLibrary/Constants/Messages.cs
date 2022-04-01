using System;

namespace ClassLibrary.Constants
{
    public static class Messages
    {
        public static string FromErrorCode(PersonErrorCode errorCode)
        {
            return errorCode switch
            {
                PersonErrorCode.Unknown => "Error desconocido.",
                PersonErrorCode.PersonAlreadyExists => "Esta persona ya ha sido registrada.",
                PersonErrorCode.InvalidBirthDate => "La fecha de nacimiento especificada no es valida.",
                PersonErrorCode.InvalidBirthState => "El estado de nacimiento especificado no es valido.",
                PersonErrorCode.InvalidFirstName => "El nombre especificado no es valido.",
                PersonErrorCode.InvalidFatherLastName => "El apellido paterno especificado no es valido.",
                PersonErrorCode.InvalidMotherLastName => "El apellido materno especificado no es valido.",
                PersonErrorCode.PersonNotFound => "La persona especificada no existe.",
                _ => throw new ArgumentOutOfRangeException(nameof(errorCode))
            };
        }
    }

}