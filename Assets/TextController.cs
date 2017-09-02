using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    enum States
    {
        cell,
        mirror,
        sheets_0,
        lock_0,
        cell_mirror,
        sheets_1,
        lock_1,
        corridor_0,
        floor,
        stairs_O,
        closet_door,
        stairs_1,
        corridor_1,
        in_closet,
        corridor_2,
        courtyard
    };

    States myState;
    public Text text;

    // Use this for initialization
    void Start()
    {
        myState = States.cell;
    }

    // Update is called once per frame
    void Update()
    {
        switch (myState)
        {
            case States.cell:
                Cell();
                break;
            case States.sheets_0:
                Sheets0();
                break;
            case States.lock_0:
                Lock0();
                break;
            case States.mirror:
                Mirror();
                break;
            case States.cell_mirror:
                CellMirror();
                break;
            case States.sheets_1:
                Sheets1();
                break;
            case States.lock_1:
                Lock1();
                break;
            case States.corridor_0:
                Corridor0();
                break;
            case States.floor:
                Floor();
                break;
            case States.stairs_O:
                Stairs0();
                break;
            case States.closet_door:
                ClosetDoor();
                break;
            case States.stairs_1:
                Stairs1();
                break;
            case States.corridor_1:
                Corridor1();
                break;
            case States.in_closet:
                InCloset();
                break;
			case States.corridor_2:
				Corridor2();
				break;
            case States.courtyard:
                Courtyard();
                break;
        }
    }

    #region State handler methods

    void Floor()
    {
        text.text = "There is a small swiss knife on the floor. It could be " +
                    "usefull !\nPress P to pick the knive, R to back.";
		if      (Input.GetKeyDown(KeyCode.P))   {myState = States.corridor_1;}
		else if (Input.GetKeyDown(KeyCode.R))   {myState = States.corridor_0;} 
    }

    void Stairs0()
    {
        text.text = "You hear fighting noise outside, you are too scared to" +
                    " climb the stairs.\nPress R to back.";

        if      (Input.GetKeyDown(KeyCode.R))   {myState = States.corridor_0;}
    }

    void ClosetDoor()
    {
        text.text = "The door of the closet is closed. The lock looks weak." +
                    "\nPress R to back.";
        if      (Input.GetKeyDown(KeyCode.R))   {myState = States.corridor_0;}
    }

    void Corridor1()
    {
        text.text = "You have a knive now. What do you want to do with it ?" +
                    "\nPress C to inspect the closet, S to check the stairs.";

		if      (Input.GetKeyDown(KeyCode.C))   {myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S))   {myState = States.stairs_1;}
    }

    void InCloset()
    {
        text.text = "You tried to open the lock with your knive and ...\n" +
                    "It worked !!! The closet is now open. There is a full armor " +
                    " and a shiny sword. With that you could fight an army !" +
                    "\nPress L to loot the closet, R to back.";
		if      (Input.GetKeyDown(KeyCode.L))   {myState = States.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.R))   {myState = States.corridor_1;}
	}

    void Corridor2()
    {
        text.text = "Same corridor, but a whole new man. It's time for you to" +
                    " kick some ass !!!\nPress S to climb the stairs";
        if      (Input.GetKeyDown(KeyCode.S))   {myState = States.stairs_1;}
    }

    void Stairs1()
    {
        text.text = "You quickly climb the stairs, there is no enemy on your " +
                    "way.\n On the top of the stairs there is an open " +
                    "door from which come an halo of light.\n" +
                    "Head outside with O, R to return in the corridor";
		if      (Input.GetKeyDown(KeyCode.O))   {myState = States.courtyard;}
		else if (Input.GetKeyDown(KeyCode.R))   {myState = States.corridor_2;}
    }

    void Courtyard()
    {
        text.text = "You are free !!!\n" +
                    "Press P to play again";

        if (Input.GetKeyDown(KeyCode.P))        {Start();}
    }

    void Cell()
    {
        text.text = "You are on a prison cell, and you want to escape. There" +
                    " are some dirty sheets on the bed, a mirror on the wall" +
                    ", and the door is locked from the outside\n" +
                    "Press S to view sheets, M to view mirror & L to view lock.";
        if      (Input.GetKeyDown(KeyCode.S))   {myState = States.sheets_0;}
        else if (Input.GetKeyDown(KeyCode.M))   {myState = States.mirror;}
        else if (Input.GetKeyDown(KeyCode.L))   {myState = States.lock_0;}
    }

    void Mirror()
    {
        text.text = "What a beautifull mirror !!!\n" +
                    "Press T to take the mirror, R to back.";
        if      (Input.GetKeyDown(KeyCode.T))   {myState = States.cell_mirror;}
        else if (Input.GetKeyDown(KeyCode.R))   {myState = States.cell;}
    }

    void Sheets0()
    {
        text.text = "Those sheets are so dirty. " +
                    "I hope i won't have to sleep here.\n" +
                    "Press R to back";

        if      (Input.GetKeyDown(KeyCode.R))   {myState = States.cell;}
    }

    void Lock0()
    {
        text.text = "I need a key to opnen this.\n" +
                    "Press R to back";
        if      (Input.GetKeyDown(KeyCode.R))   {myState = States.cell;}
    }

    void CellMirror()
    {
        text.text = "The cell feel a bit diferrent.\n" +
                    "Press S to view sheets, L to view lock.";
        if      (Input.GetKeyDown(KeyCode.S))   {myState = States.sheets_1;}
        else if (Input.GetKeyDown(KeyCode.L))   {myState = States.lock_1;}
    }

    void Sheets1()
    {
        text.text = "Sheets are still as dirty as before.\n" +
                    "Press R to back.";
        if      (Input.GetKeyDown(KeyCode.R))   {myState = States.cell_mirror;}
    }

    void Lock1()
    {
        text.text = "The locks seems open !!!.\n" +
                    "Press F to be free or R to back.";
        if      (Input.GetKeyDown(KeyCode.F))   {myState = States.corridor_0;}
        else if (Input.GetKeyDown(KeyCode.R))   {myState = States.cell_mirror;}
    }

    void Corridor0()
    {
        text.text = "You enter a dark corridor. There is a closet on one side" +
                    ", and stairs on the other.\nPress S to check the stairs" +
                    ", F the floor and C the closet.";
		if      (Input.GetKeyDown(KeyCode.F))   {myState = States.floor;}
		else if (Input.GetKeyDown(KeyCode.S))   {myState = States.stairs_O;}
        else if (Input.GetKeyDown(KeyCode.C))   {myState = States.closet_door;}
    }

    #endregion
}
