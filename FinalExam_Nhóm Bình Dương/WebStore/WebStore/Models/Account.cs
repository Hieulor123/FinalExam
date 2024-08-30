using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Account
    {
        public string UserName { get; set; }

        //[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[~!@#$%^&*-+])[A-Za-z0-9~!@#$%^&*-+]{6,}$", ErrorMessage = "Mật khẩu phải có tối thiểu 6 kí tự bao gồm ít nhất 1 chữ hoa, 1 chữ thường, 1 ký tự đặc biệt và 1 chữ số.")]
        public string Password { get; set; }

        [MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        [StringLength(100, ErrorMessage = "Tối đa 100 kí tự")]
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Chưa đúng định dạng.")]
        public string Email { get; set; }

        //[RegularExpression("0[98753][0-9]{8}",ErrorMessage = "Chưa đúng định dạng.")]
        public string Phone { get; set; }
        public int Authority { get; set; }


    }
}
