﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.Decompiler;
using ICSharpCode.NRefactory.CSharp;
using JetBrains.Annotations;
using TryRoslyn.Core.Decompilation.Support;

namespace TryRoslyn.Core.Decompilation {
    [ThreadSafe]
    public class CSharpDecompiler : AstDecompiler {
        protected override void WriteResult(TextWriter writer, IEnumerable<AstNode> ast, DecompilerContext context) {
            var visitor = new DecompiledPseudoCSharpOutputVisitor(
                new TextWriterOutputFormatter(writer) {
                    IndentationString = "    "
                },
                context.Settings.CSharpFormattingOptions
            );

            foreach (var node in ast) {
                node.AcceptVisitor(visitor);
            }
        }

        public override LanguageIdentifier Language {
            get { return LanguageIdentifier.CSharp; }
        }
    }
}