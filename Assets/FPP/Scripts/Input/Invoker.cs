﻿using UnityEngine;
using System.Linq;
using FPP.Scripts.Enums;
using FPP.Scripts.Patterns;
using System.Collections.Generic;

namespace FPP.Scripts.Input
{
    class Invoker : MonoBehaviour
    {
        private bool _isRecording;
        private bool _isReplaying;
        private float _replayTime;
        private float _recordingTime;
        private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, Record);
            RaceEventBus.Subscribe(RaceEventType.FINISH, SaveReplay);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, Record);
            RaceEventBus.Unsubscribe(RaceEventType.FINISH, SaveReplay);
        }

        public void ExecuteCommand(Command command)
        {
            command.Execute();
            if (_isRecording) _recordedCommands.Add(_recordingTime, command);
        }

        public void Record()
        {
            _recordingTime = 0.0f;
            _isRecording = !_isRecording;
        }

        public void Replay()
        {
            _replayTime = 0.0f;
            _isReplaying = !_isReplaying;
            _recordedCommands.Reverse();
        }

        public void SaveReplay()
        {
            //byte[] bytes = SerializationUtility.SerializeValue(_recordedCommands, DataFormat.Binary);
            //File.WriteAllBytes(Application.dataPath + "/replay.bin", bytes);
        }

        void FixedUpdate()
        {
            if (_isRecording)
                _recordingTime += Time.deltaTime;

            if (_isReplaying)
            {
                _replayTime += Time.deltaTime;
                if (_recordedCommands.Any())
                {
                    if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                    {
                        _recordedCommands.Values[0].Execute();
                        _recordedCommands.RemoveAt(0);
                    }
                }
            }
        }
    }
}