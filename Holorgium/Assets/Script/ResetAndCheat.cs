using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResetAndCheat : MonoBehaviour
{

    [SerializeField] int sceneToLoad = 1;
    [SerializeField] Image image;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            StartCoroutine(FadeOutReload());
        }
        if(Input.GetKeyDown(KeyCode.T)){
            StartCoroutine(FadeOut());
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        StartCoroutine(FadeOutReload());
    }

    IEnumerator FadeOut(){

        for (float i = 0f; i < 1; i+= Time.deltaTime){
            image.color = new Color(image.color.r, image.color.g,image.color.b,i);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadSceneAsync(sceneToLoad,LoadSceneMode.Single);
        yield return null;
    }

    IEnumerator FadeOutReload(){

        for (float i = 0f; i < 1; i+= Time.deltaTime){
            image.color = new Color(image.color.r, image.color.g,image.color.b,i);
            yield return new WaitForEndOfFrame();
        }
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadSceneAsync(scene.name);
        yield return null;
    }

    IEnumerator FadeIn(){

        for (float i = 1f; i > 0; i-= Time.deltaTime){
            Debug.Log(i);
            image.color = new Color(image.color.r, image.color.g,image.color.b,i);
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }



}
