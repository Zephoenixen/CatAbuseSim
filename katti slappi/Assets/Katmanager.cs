using System.Diagnostics;
using System.Linq;

public class Katmanager : MonoBehaviour
{
    //Liste af ting der skal bruges
    public GameObject Ost;
    public GameObject Patooty;
    public GameObject Fernando;
    public GameObject Placeholder1;

    public Vector2 Katstpos = new Vector2(-20, -20);
    public Vector3 Vel = new Vector3(0, 2, 0);
    public Vector3 Bonk = new Vector3(0, -7, 0);
    public bool[] PosAvaliable;
    public int[] Pos;
    public bool[] KatAvaliable;
    public Rigidbody2D Ferb;
    public Rigidbody2D Osrb;
    public Rigidbody2D Parb;
    public Rigidbody2D Plrb;
    // Start is called before the first frame update
    void Start()
    {

        //Flytter kattene langt væk fra skærmen
        Patooty.transform.position = Katstpos;
        Ost.transform.position = Katstpos;
        Fernando.transform.position = Katstpos;
        Placeholder1.transform.position = Katstpos;

        KatMover();
    }

    void KatMover()
    {
        int RandoPos = Random.Range(0, Pos.Length);

        if ((PosAvaliable[RandoPos] == true))
        {
            int RandoKat = Random.Range(0, KatAvaliable.Length);

            if ((KatAvaliable[RandoKat] == true))
            {
                PosAvaliable[RandoPos] = false;
                KatAvaliable[RandoKat] = false;
                Debug.Log("bevægelse");
                if (RandoKat == 0)
                {
                    Fernando.transform.position = Pos[RandoPos];
                    Ferb.velocity = Vel;
                }
                else if (RandoKat == 1)
                {
                    Ost.transform.position = Pos[RandoPos];
                    Osrb.velocity = Vel;
                }
                else if (RandoKat == 2)
                {
                    Patooty.transform.position = Pos[RandoPos];
                    Parb.velocity = Vel;
                }
                else if (RandoKat == 3)
                {
                    Placeholder1.transform.position = Pos[RandoPos];
                    Plrb.velocity = Vel;
                }
                else { Debug.Log("KatMover Broke")}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow)) && (PosAvaliable[2] = false))
        {
            ;
        }
        if (!PosAvaliable.All(PosAvaliable[] == true)) {; }

        //if (dead.All(dead[] == true))


    }
}
