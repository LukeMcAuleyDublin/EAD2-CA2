package org.gc.helloworldvolleyclient;

public class Song
{
    private int ID;
    private String Name;
    private String Length;
    private String Genre;
    private String Lyrics;

    private int ArtistID;


    public String ToString()
    {
        String toReturn = "ID: " + Integer.toString(ID) + "\nArtist: " + Integer.toString(ArtistID)
                +"\nLength: " + Length + "\nGenre: " + Genre;
        return toReturn;
    }
}