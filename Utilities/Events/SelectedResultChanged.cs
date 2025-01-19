using AnimeVoices.Models;

namespace AnimeVoices.Utilities.Events
{
    public record SelectedResultChanged(Result? result, Character? character);
}
