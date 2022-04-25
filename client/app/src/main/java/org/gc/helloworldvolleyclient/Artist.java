package org.gc.helloworldvolleyclient;

import com.google.gson.annotations.SerializedName;

public class Artist {
    private int id;

    private String name;

    private String bio;

    private int yearFormed;

    @Override
    public String toString()
    {
        return "\nName: " + name + "\nBio: " + bio + "\nYear Formed: " + yearFormed + "\n";
    }
}