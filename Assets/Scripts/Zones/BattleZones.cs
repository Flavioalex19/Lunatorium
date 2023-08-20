using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleZones : MonoBehaviour
{

    [SerializeField] GameObject limitCubeWalls;//afte the battle starts, thew player will be unable to escape, this object will be set active at the beginning of the battle
    [SerializeField] List<Transform> _spawnList = new List<Transform>();
    float _countEnemies = 0;
    public bool _isSpawnCompleted = false;
    [SerializeField]List<GameObject> listEnemies = new List<GameObject>();
    string _names = "Enemy";

    #region Zone stats
    public bool _isActive = false;
    public bool _isCleared = false;
    public bool _hasSpawnedEnemies = false;
    #endregion

    bool _sfxHasStarted = false;

    GameObject _cc_Player;

    PoolerManager _poolerManager;
    UiManager _uiManager;
    Sfx_Manager _sfx_Manager;

    private void Start()
    {
        _poolerManager = GameObject.Find("Game Manager").GetComponent<PoolerManager>();
        _uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        _sfx_Manager = GameObject.Find("SFX Manager").GetComponent<Sfx_Manager>();

        limitCubeWalls.SetActive(false);

        
    }

    private void Update()
    {
        if (_isActive)
        {
            _uiManager.SetIsMindBarActive(true);
            _cc_Player.GetComponent<Stats>().SetIsUnderPress(true);
            if (!_isSpawnCompleted)
            {
                for (int i = 0; i < _spawnList.Count; i++)
                {
                    if (_countEnemies < _spawnList.Count)
                    {
                        _poolerManager.SpawnFromPool(_names, _spawnList[i].position, _spawnList[i].rotation, listEnemies);
                    }

                    _countEnemies++;
                }
                for (int i = 0; i < listEnemies.Count; i++)
                {
                    listEnemies[i].GetComponent<AI>()._target = _cc_Player.transform;
                    listEnemies[i].GetComponent<AI>().AiState = AiState.Pursuit;
                }
                _isSpawnCompleted=true;
            }
            

            //If there is no more enemies, clear the zone
            if (_spawnList.Count == 0)
            {
                _isCleared = true;
            }
            if (_isCleared)
            {
                if (_cc_Player != null)
                {
                    _isActive = false;
                    _cc_Player.GetComponent<PlayerInput>()._isInCombat = false;
                    _cc_Player.GetComponent<Stats>().SetIsUnderPress(false);
                    _cc_Player.GetComponent<Stats>().RestoreMind();
                    _uiManager.SetIsMindBarActive(false);
                }
            }
            else
            {
                
                if (_cc_Player != null)
                {
                    
                    //Change heartbeat in relation to mind
                    if (_cc_Player.GetComponent<Stats>().GetCurrentMind() < _cc_Player.GetComponent<Stats>().GetMind() / 2)
                    {
                        //_sfx_Manager.StartSFXHeartBeat();
                        
                        _sfx_Manager.changeHeardbeatClip(1);
                    }

                }
            }

            if(_sfxHasStarted == false)
            {
                _sfx_Manager.StartSFXHeartBeat();
                _sfxHasStarted = true;
            }
  

        }
       

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            _cc_Player = other.gameObject;
            _cc_Player.GetComponent<PlayerInput>()._isInCombat = true;
            _isActive = true;
            limitCubeWalls.SetActive(true);
            //_cc_Player.GetComponent<Stats>().SetIsUnderPress(true);
        }
    }
    
}