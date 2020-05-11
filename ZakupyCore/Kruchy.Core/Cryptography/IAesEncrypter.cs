using System;
using System.Collections.Generic;
using System.Text;

namespace Kruchy.Core.Cryptography
{
    public interface IAesEncrypter
    {
        byte[] Encode(string source);

        string Decode(byte[] source);
    }
}
