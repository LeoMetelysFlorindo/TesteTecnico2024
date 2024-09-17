using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUMUP.API.Models
{
    /// <summary>
    /// Model to retrieve information for Token. 
    /// </summary>    
    /// <returns>A list with values generate from a string sql.</returns> 
    public class Users
    {
        /// <summary>
        /// Username internal define to generate token Acess: NKG_Taiwan.
        /// </summary>    
        /// <returns>string value</returns>

        public string Username { get; set; }

        /// <summary>
        /// Password internal define to generate token Acess: NGK@2505_21. 
        /// </summary>    
        /// <returns>string value</returns>
        public string Password { get; set; }

        /// <summary>
        /// Role internal to generate token Acess: manager.
        /// </summary>    
        /// <returns>string value</returns>
        public string Role { get; set; }
    }
}
