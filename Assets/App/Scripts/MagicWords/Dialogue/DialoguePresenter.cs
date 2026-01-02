using System;
using System.Collections.Generic;
using System.Linq;
using App.Tools;
using Cysharp.Threading.Tasks;
using VContainer.Unity;
using UniRx;
using UnityEngine;

namespace App.MagicWords
{
    public class DialoguePresenter :  BaseDisposable, IInitializable
    {
        private readonly LoaderService _loaderService;
        private readonly DialogueFactory _dialogueFactory;
        private readonly AvatarLoader _avatarLoader;

        private readonly Dictionary<string, Texture2D> _avatarsTexturesCache = new();

        public DialoguePresenter(LoaderService loaderService, DialogueFactory dialogueFactory, AvatarLoader avatarLoader)
        {
            _loaderService = loaderService;
            _dialogueFactory = dialogueFactory;
            _avatarLoader = avatarLoader;
        }
        
        public void Initialize()
        {
            AddDisposable(
                _loaderService.OnDataLoaded.Subscribe(InitializeInternal));
        }

        private void InitializeInternal(WordsData wordsData)
        {
            InitializeAsync(wordsData);
        }

        private async UniTaskVoid InitializeAsync(WordsData wordsData)
        {
            await CacheAvatarsTextures(wordsData);
            
            var view = _dialogueFactory.CreateDialogueView();
            AddDisposable(new GameObjectDisposer(view.gameObject));

            view.Show(wordsData);
        }

        private async UniTask CacheAvatarsTextures(WordsData data)
        {
            var namesInDialogue = data.dialogue.Select(x => x.name).Distinct().ToList();
            foreach (var name in namesInDialogue)
            {
                if (_avatarsTexturesCache.ContainsKey(name))
                    continue;

                Texture2D avatarTexture;
                var urls = data.avatars.Select(x => x.name == name).ToList();
                foreach (var url in urls)
                {
                    try
                    {
                        avatarTexture = await _avatarLoader.LoadAvatarAsync(url);
                    }
                    catch
                    {
                        Debug.LogError($"Avatar texture loading failed. Name: {name}");
                        continue;
                    } 
                }

                if (avatarTexture != null)
                    _avatarsTexturesCache[name] = avatarTexture;
            }
        }
    }
}