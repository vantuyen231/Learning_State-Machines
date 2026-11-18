using UnityEngine;

[RequireComponent(typeof(ChestView))]
public class ChestController : MonoBehaviour
{
    [SerializeField] private ChestView _chestView;
    [SerializeField] private bool _isClose;

    private void Awake()
    {
        _chestView = GetComponent<ChestView>();
        _isClose = true;
    }


    private void OnEnable()
    {
        _chestView.OnClick += OnClicked;
    }

    private void OnDisable()
    {
        _chestView.OnClick -= OnClicked;
    }

    private void OnClicked()
    {
        Debug.Log("Clicked");
        if (_isClose)
        {
            _chestView.OpenChest();
            _isClose = false;
        }
        else
        {
            _chestView.CloseChest();
            _isClose = true;
        }
    }
}
