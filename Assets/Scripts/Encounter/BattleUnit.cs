using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] public PokemonBase Base;
    [SerializeField] public int Level;
    [SerializeField] public bool isPlayerUnit;

    public Pokemon Pokemon;

    private Image image;
    private Vector3 originalPosition;

    private void Start()
    {
        image = GetComponent<Image>();
        originalPosition = image.transform.localPosition;
    }

    public void SetUp()
    {
        Pokemon = new Pokemon(Base, Level);
        image.sprite = isPlayerUnit ? Pokemon.Base.BackSprite : Pokemon.Base.PokemonSprite;
    }
    
    public void PlayEnterAnimation()
    {
        image.transform.localPosition = isPlayerUnit ? 
            new Vector3(-500f, originalPosition.y) : 
            new Vector3(500f, originalPosition.y);

        image.transform.DOLocalMoveX(originalPosition.x, 1f);
    }

    public void PlayAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(isPlayerUnit
            ? image.transform.DOLocalMoveX(originalPosition.x + 50f, 0.25f)
            : image.transform.DOLocalMoveX(originalPosition.x - 50f, 0.25f));

        sequence.Append(image.transform.DOLocalMoveX(originalPosition.x, 0.25f));
    }
    
    public void PlayHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.gray, 0.1f));
        sequence.Append(image.DOColor(Color.white, 0.1f));
    }
    
    public void PlayFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originalPosition.y - 150f, 0.5f));
        sequence.Join(image.DOFade(0f, 0.5f));
    }
}
