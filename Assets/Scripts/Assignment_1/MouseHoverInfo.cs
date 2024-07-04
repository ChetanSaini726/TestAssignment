using TMPro;
using UnityEngine;

public class MouseHoverInfo : MonoBehaviour
{
    public TMP_Text tileInfoText;
    public LayerMask tileLayer;

    // Update is called once per frame
    void Update()
    {
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f, tileLayer) )
        {
            TileInfo tileInfo = hit.collider.GetComponent<TileInfo>();

            if( tileInfo != null )
            {
                tileInfoText.gameObject.SetActive( true );
                tileInfoText.text = $"Tile Info: {tileInfo.tileId.x}, {tileInfo.tileId.y}";
                tileInfoText.rectTransform.position = Input.mousePosition / tileInfoText.transform.localScale.x;
            }
            
        }
        else
        {
            tileInfoText.gameObject.SetActive(false);
        }
    }
}
