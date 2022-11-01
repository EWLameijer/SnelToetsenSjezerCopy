using SnelToetsenSjezer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnelToetsenSjezer.Domain.Models
{
    /// <summary>
    /// SolutionStepPart is a basic object with a Type and Value.<br/>
    /// - <i>SolutionStepPartType</i> <b>Type</b><br/>
    /// - <i>string</i> <b>Value</b><br/>
    /// <br/>
    /// 'Step-parts' are the different bits that come together to form a HotKeySolutionStep of a HotKeySolution, a step<br/>
    /// can be a single entry (ex: ".. ,A, ..") or multiple entrys (ex: ".. ,A+B+C, ..") or a string (ex ".. ,'abc', ..")<br/>
    /// so thats where these step-parts come in to play, they are 'the bits between the commas, seperated out'
    /// </summary>
    public class SolutionStepPart
    {
        public SolutionStepPartType Type { get; set; }
        public string Value { get; set; } = string.Empty;

        public override string ToString()
        {
            return Value;
        }
    }
}
