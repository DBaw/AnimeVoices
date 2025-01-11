using AnimeVoices.Models;

namespace AnimeVoices.Utilities.Events
{
    public record SelectedCharacterChanged(Character? character, Seiyuu? seiyuu);
}
