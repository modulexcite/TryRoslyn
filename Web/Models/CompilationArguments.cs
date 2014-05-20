﻿using JetBrains.Annotations;
using Newtonsoft.Json;

namespace TryRoslyn.Web.Models {
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class CompilationArguments {
        public string Code { get; set; }
        public CompilationMode Mode { get; set; }
        [JsonProperty("optimizations")]
        public bool OptimizationsEnabled { get; set; }
        public string Branch { get; set; }
    }
}