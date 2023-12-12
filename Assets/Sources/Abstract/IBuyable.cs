using System;

public interface IBuyable
{
    public event Action Purchased;

    public void Byu();
}