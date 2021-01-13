using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockList { Spring, Spike, FallingPlataform };
public class BlockRulerSelections : MonoBehaviour {

    public BlockList BlockType = BlockList.Spring;

    private void Start() {
        if (BlockType == BlockList.Spring) {
            
        }
        switch(BlockType) {
            case BlockList.Spring:
                new SpringBlock(this.gameObject);
                break;
            case BlockList.Spike:
                new SpikeBlock(this.gameObject);
                break;
            case BlockList.FallingPlataform:
                new FallingBlock(this.gameObject);
                break;
        }
    }

}
