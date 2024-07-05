using UnityEngine;

public class DialogueManager : DialogueSystem
{
    public static DialogueManager Instance;

    private void Awake() {
        Instance = this;
    }
    protected override void Start()
    {
        base.Start();
        StartDialog();
        DisplayNextDialog();
    }

    protected override void Update()
    {
        base.Update();
    }
}
