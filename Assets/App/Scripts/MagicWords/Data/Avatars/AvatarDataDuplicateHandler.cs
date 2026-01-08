namespace App.MagicWords
{
    public static class AvatarDataDuplicateHandler
    {
        public static void HandleDuplicate(AvatarData original, AvatarData duplicate)
        {
            if (duplicate.Sprite != null)
            {
                original.Sprite = duplicate.Sprite;
                original.Position = duplicate.Position;
            }
        }
    }
}