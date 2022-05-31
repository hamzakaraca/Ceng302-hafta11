using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Void metotlarım için  hata yönetiminde kullanacağım kısım
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
