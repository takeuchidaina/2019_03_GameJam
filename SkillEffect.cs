using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Canvasにこのスクリプトをアタッチしてください。
/// CanvasにAudioSourceをアタッチしてください。
/// </summary>
public class SkillEffect : MonoBehaviour {
    

	// width 250 height 50 の　Imageを作成してアタッチしてください
	[SerializeField] private RectTransform r_player;
	[SerializeField] private RectTransform b_player;

	private readonly Vector3 defaultPos_r = new Vector3(-600, 25, 0);
	private readonly Vector3 movePos_r = new Vector3(-50, 25, 0); 
	private readonly Vector3 movePos_r1 = new Vector3(600, 25, 0);

	private readonly Vector3 defaultPos_b = new Vector3(600, -25, 0);
    private readonly Vector3 movePos_b = new Vector3(50, -25, 0);
    private readonly Vector3 movePos_b1 = new Vector3(-600, -25, 0);

	private Sequence sequence_r;
	private Sequence sequence_b;

	private AudioSource audio;
    
	// Use this for initialization
	public void Init() {
		
		sequence_r = DOTween.Sequence();
		sequence_b = DOTween.Sequence();

		r_player.localPosition = defaultPos_r;
		b_player.localPosition = defaultPos_b;

		audio = this.GetComponent<AudioSource>();
	}


	public void CutIn(){
       
		sequence_r.Append(r_player.DOLocalMove(movePos_r, 0.5f).OnComplete(() => audio.PlayOneShot(audio.clip)));
		sequence_r.Append(r_player.DOScale(new Vector3(1.01f, 1.01f, 1.01f), 1.5f));
		sequence_r.Append(r_player.DOLocalMove(movePos_r1, 0.5f));

        sequence_b.Append(b_player.DOLocalMove(movePos_b, 0.5f));
        sequence_b.Append(b_player.DOScale(new Vector3(1.01f, 1.01f, 1.01f), 1.5f));
        sequence_b.Append(b_player.DOLocalMove(movePos_b1, 0.5f));
        
		sequence_r.Play(); 
		sequence_b.Play();

	}
}
