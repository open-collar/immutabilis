using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace immutabilis;

/// <summary>
/// The available result codes for the application.
/// </summary>
public enum ResultCode
{
    /// <summary>
    /// The application completed successfully.
    /// </summary>

    Success = 0,

    /// <summary>
    /// No arguments were supplied.
    /// </summary>
    NoArgs = 1
}