using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class TemplateMethodPatternExercise2 : MonoBehaviour
    {
        private void Start()
        {
            DataMiner csv = new CSVDataMiner();
            csv.mine("csv path");

            DataMiner pdf = new PDFDataMiner();
            csv.mine("pdf path");
        }

        public abstract class DataMiner
        {
            protected string file;
            protected string rawData;

            public virtual void openFile(string path)
            {
                Debug.Log("Open " + path);
            }
            public virtual void closeFile()
            {
                Debug.Log("Close file\n");
            }
            public abstract void extractData();
            public abstract void parseData();

            public void mine(string path)
            {
                openFile(path);
                extractData();
                parseData();
                closeFile();
            }
        }

        public class CSVDataMiner : DataMiner
        {
            public override void extractData()
            {
                Debug.Log("Extract CSV");
            }

            public override void parseData()
            {
                Debug.Log("Parse CSV");
            }
        }

        public class PDFDataMiner : DataMiner
        {
            public override void openFile(string path)
            {
                base.openFile(path);
                this.file = "PDF";
            }
            public override void extractData()
            {
                Debug.Log("Extract " + this.file);
                this.rawData = "PDF";
            }

            public override void parseData()
            {
                Debug.Log("Parse " + this.rawData);
            }
        }
    }
}