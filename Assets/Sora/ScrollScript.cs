using UnityEngine;

public class SpriteScroll : MonoBehaviour
{
	[SerializeField] private float scrollSpeedX = 0.1f;
	[SerializeField] private float scrollSpeedY = 0.1f;

	private Renderer _renderer;
	private Vector2 _offset;

	void Start()
	{
		_renderer = GetComponent<Renderer>();
	}

	void Update()
	{
		// オフセット値を計算
		float x = Mathf.Repeat(Time.time * scrollSpeedX, 1);
		float y = Mathf.Repeat(Time.time * scrollSpeedY, 1);
		_offset = new Vector2(x, y);

		// マテリアルのオフセットを変更
		// 注意: materialへのアクセスはインスタンスを生成するため、大量のオブジェクトに行うとメモリ負荷がかかります
		_renderer.material.mainTextureOffset = _offset;
	}

	// 終了時にマテリアルのインスタンス破棄などを考慮するのがベストプラクティスですが、
	// 簡易的な利用であれば上記で動作します。
}


/*
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField, Range(-1, 1)]
	float m_scrollSpeedX = 1.0f;
	[SerializeField, Range(-1, 1)]
	float m_scrollSpeedY = 1.0f;

	Image m_image;
	Material m_material;

	void Start()
	{
		m_image = gameObject.GetComponent<Image>();

		// 他に影響を与えないためにマテリアルを複製
		m_material = new Material(m_image.material);
		m_image.material = m_material;
	}

	void Update()
	{
		if (m_image == null || m_material == null)
			return;

		// 現在のオフセットを取得
		Vector2 offset = m_image.material.mainTextureOffset;

		// X軸のスクロール
		if (m_scrollSpeedX != 0.0f)
		{
			offset.x += m_scrollSpeedX * Time.deltaTime;
		}

		// Y軸のスクロール
		if (m_scrollSpeedY != 0.0f)
		{
			offset.y += m_scrollSpeedY * Time.deltaTime;
		}

		// 更新したオフセットをマテリアルに適用
		m_image.material.mainTextureOffset = offset;
	}

	private void OnDestroy()
	{
		// マテリアルの消去
		Destroy(m_material);
	}
}
*/