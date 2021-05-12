namespace RRUI
{/// <summary>
/// Standardized validation service for basic user input to make sure they're inputting valid stuff
/// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Takes in a prompt, and keeps asking that prompt till the end user returns a valid string
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        string ValidateString(string prompt);
    }
}