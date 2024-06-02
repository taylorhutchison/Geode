using System;
using System.IO;

namespace Geode;
internal abstract class Reader
{
    internal string NullStreamExceptionMessage => "Stream is null and must be initialized before use.";

    internal byte[] ReadBytesFromStream(Stream readStream, int numBytesRequested)
    {
        if (readStream == null)
        {
            throw new NullReferenceException(NullStreamExceptionMessage);
        }
        else if (!readStream.CanRead)
        {
            throw new IOException("Unable to read from stream." + readStream.ToString());
        }

        var bufferBytes = new byte[numBytesRequested];
        var totalBytesRead = 0;
        var bytesRead = 0;
        do
        {
            bytesRead = readStream.Read(bufferBytes, totalBytesRead, numBytesRequested - totalBytesRead);
            if (bytesRead == 0)
            {
                var resizedBufferBytes = new byte[totalBytesRead];
                Array.Copy(bufferBytes, resizedBufferBytes, totalBytesRead);
                return resizedBufferBytes;
            }
            else
            {
                totalBytesRead += bytesRead;
            }
        } while (totalBytesRead < numBytesRequested);

        return bufferBytes;
    }

    internal byte[] ReadBytesFromStream(Stream stream, long startPosition, int numBytesRequested)
    {
        byte[] bufferBytes = new byte[numBytesRequested];
        int totalBytesRead = 0;
        int bytesRead = 0;
        do
        {
            bytesRead = stream.Read(bufferBytes, totalBytesRead, numBytesRequested - totalBytesRead);
            if (bytesRead == 0)
            {
                byte[] resizedBufferBytes = new byte[totalBytesRead];
                Array.Copy(bufferBytes, resizedBufferBytes, totalBytesRead);
                return resizedBufferBytes;
            }
            else
            {
                totalBytesRead += bytesRead;
            }
        } while (totalBytesRead < numBytesRequested);
        return bufferBytes;
    }
}
