using LSL;
using System.Collections;
using System.Collections.Generic;
using Tobii.Research.Unity;
using UnityEngine;

public class TobiiProGazeDataLSLOutletController : LSLOutletInterface
{
    // Start is called before the first frame update


    private EyeTracker _eyeTracker;
    //public StreamOutlet streamOutlet;

    void Start()
    {
        _eyeTracker = EyeTracker.Instance;
        initLSLStreamOutlet(                                               
                    Presets.GazeDataLSLOutletStreamName,
                    Presets.GazeDataLSLOutletStreamType,
                    Presets.GazeDataChannelNum,
                    Presets.GazeDataNominalSamplingRate,
                    LSL.channel_format_t.cf_float32
                    );
        

        //initLSLTobiiProGazeDataOutlet();
    }

    // Update is called once per frame
    void Update()
    {

        var data = _eyeTracker.NextData;
        while (data != default(IGazeData))
        {
            float startTime = Time.time;
            float[] gazeDataArray = new float[51];
            GazeDataUtils.UnpackGazeData(data, gazeDataArray);
            float timestamp = gazeDataArray[50] / 1000000;
            streamOutlet.push_sample(gazeDataArray, timestamp);
            float endTime = Time.time;
            //Debug.Log(startTime-endTime);

            data = _eyeTracker.NextData;
            

        }
    }

    // unpack data
    //void initLSLTobiiProGazeDataOutlet()
    //{
    //    // TODO: init gaze data outlet LSL
    //    StreamInfo streamInfo = new StreamInfo(
    //                                            Presets.GazeDataLSLOutletStreamName,
    //                                            Presets.GazeDataLSLOutletStreamType,
    //                                            Presets.GazeDataChannelNum,
    //                                            Presets.GazeDataNominalSamplingRate,
    //                                            LSL.channel_format_t.cf_float32
    //                                            );

    //    streamOutlet = new StreamOutlet(streamInfo);

    //}
    


}
