using System;
using System.Net.Mail;
using System.Net.Security;

public class GameObject
{
	public int getID;
	public string name;
	public int getX;
	public int getY;

	public GameObject(int getID, string name, int getX, int getY)
    {
        this.getID = getID;
		this.name = name;
		this.getX = getX;
		this.getY = getY;
    }
}

public class Unit : GameObject
{
	public bool isAlive;
	public float getHp;

	public Unit(bool isAlive, float getHp, int getID, string name, int getX, int getY) : base(getID, name, getX, getY)
	{
		this.isAlive = true;
		this.getHp = getHp;
	}

	public bool Alive()
	{
		return isAlive;
	}

	public void reciveDamage(float damage)
	{
		getHp -= damage;
		if (getHp <= 0)
		{
			isAlive = false;
		}
		else
		{
			isAlive = true;
		}
	}
}

public class Archer: Unit, Attacker, Moveable
{
	public Archer(bool isAlive, float getHp, int getID, string name, int getX, int getY) : base(isAlive, getHp, getID, name, getX, getY)
	{

	}

	public void Attack(Unit unit)
	{
		if (unit.Alive())
		{
			unit.reciveDamage(10);
		}
	}

	public void Move(int newX, int newY)
	{
		newX = getX + 1;
		newY = getY + 1;
	}
}

public class Building: GameObject
{
	protected bool isBuild;
	public Building(int getID, string name, int getX, int getY, bool isBuild): base(getID, name, getX, getY)
	{
		this.isBuild = isBuild;
	}

	public bool isBuilt()
	{
		return isBuild;
	}
}

public interface Attacker
{
	void Attack(Unit unit);
}

public interface Moveable
{
	void Move(int newX, int newY);
}

public class Fort: Building, Attacker
{
    public Fort(int getID, string name, int getX, int getY, bool isBuild): base(getID, name, getX, getY, isBuild)
    {
        
    }

	public void Attack(Unit unit)
	{
		if (unit.Alive() && isBuilt())
		{
			unit.reciveDamage(10);
		}
	}
}

public class ModileHouse: Building, Moveable
{
    public ModileHouse(int getID, string name, int getX, int getY, bool isBuild): base(getID, name, getX, getY, isBuild)
    {
        
    }

	public void Move(int newX, int newY)
	{
		if (isBuild)
		{
			newX = getX + 1;
			newY = getY + 1;
		}
	}
}

	
class Program
{
	static void Main(string[] args)
	{
		Archer archer = new Archer(true, 100.0f, 1, "gleb", 0, 0);
		archer.Attack(archer);
		Console.WriteLine(archer.getHp);
	}
}
