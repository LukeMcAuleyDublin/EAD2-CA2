package org.gc.helloworldvolleyclient;

public class Song {
    private int id;
    private String name;
    private String length;
    private String genre;
    private String lyrics;

    private int artistId;

    @Override
    public String toString()
    {
        String toReturn = "ID: " + Integer.toString(id) + "\nName: " + name + "\nArtist: " + Integer.toString(artistId)
                +"\nLength: " + length + "\nGenre: " + genre + "\n";
        return toReturn;
    }
}