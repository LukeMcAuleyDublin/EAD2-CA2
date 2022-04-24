package org.gc.helloworldvolleyclient;

import android.os.Bundle;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.util.Log;
import android.widget.Button;
import android.widget.TextView;
import com.google.gson.*;
import com.android.volley.*;
import com.android.volley.toolbox.*;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.lang.reflect.Type;
import com.google.gson.reflect.TypeToken;

public class MainActivity extends AppCompatActivity {

    // uri of RESTful service on Azure
    private static final String SERVICE_URI = "https://ead2ca2-project-deploy.azurewebsites.net/api";// https
    private String TAG = "Luke McAuley:";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        Button getArtistButton = (Button) findViewById(R.id.getArtistsButton);
        getArtistButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                getArtists(view);
            }
        });

        Button getSongsButton = (Button) findViewById(R.id.getSongsButton);
        getSongsButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                getSongs(view);
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        return super.onOptionsItemSelected(item);
    }

    // This is a function to call the /api/artist endpoint
    public void getArtists(View v)
    {
        final TextView outputTextView = (TextView) findViewById(R.id.outputTextView);

        try
        {
            RequestQueue queue = Volley.newRequestQueue(this);
            Log.d(TAG, "Making request to /api/artists/");
            try
            {
                StringRequest strObjRequest = new StringRequest(Request.Method.GET, SERVICE_URI + "/artists",
                        new Response.Listener<String>()
                        {
                            @Override
                            public void onResponse(String response)
                            {
                                Gson gson = new Gson();
                                Artist[] artists = gson.fromJson(response, Artist[].class);
                                for(Artist a: artists)
                                {
                                    outputTextView.setText(a.toString());
                                    Log.d(TAG, "Data: " + a.toString());

                                }
                            }
                        },
                        new Response.ErrorListener()
                        {
                            @Override
                            public void onErrorResponse(VolleyError error)
                            {
                                outputTextView.setText(error.toString());
                                Log.d(TAG, "Error" + error.toString());
                            }
                        });
                queue.add(strObjRequest);
            }
            catch (Exception e2)
            {
                Log.d(TAG, e2.toString());
                outputTextView.setText(e2.toString());
            }
        }
        catch (Exception e1)
        {
            Log.d(TAG, e1.toString());
            outputTextView.setText(e1.toString());
        }
    }

    public void getSongs(View v)
    {
        final TextView outputTextView = (TextView) findViewById(R.id.outputTextView);

        try
        {
            RequestQueue queue = Volley.newRequestQueue(this);
            Log.d(TAG, "Making request to /api/songs/");
            try
            {
                StringRequest strObjRequest = new StringRequest(Request.Method.GET, SERVICE_URI + "/songs",
                        new Response.Listener<String>()
                        {
                            @Override
                            public void onResponse(String response) {
                                Gson gson = new Gson();
                                Song[] songs = gson.fromJson(response, Song[].class);
                                for (Song s : songs) {
                                    outputTextView.setText(s.toString());
                                    Log.d(TAG, "Data: " + s.toString());

                                }
                            }
                        },
                        new Response.ErrorListener()
                        {
                            @Override
                            public void onErrorResponse(VolleyError error)
                            {
                                outputTextView.setText(error.toString());
                                Log.d(TAG, "Error" + error.toString());
                            }
                        });
                queue.add(strObjRequest);
            }
            catch (Exception e2)
            {
                Log.d(TAG, e2.toString());
                outputTextView.setText(e2.toString());
            }
        }
        catch (Exception e1)
        {
            Log.d(TAG, e1.toString());
            outputTextView.setText(e1.toString());
        }
    }
}