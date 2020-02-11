﻿using PipelineLauncher.Abstractions.PipelineRunner;
using System.Collections.Generic;
using System.Linq;
using PipelineLauncher.Demo.Tests.PipelineSetup;

namespace PipelineLauncher.Demo.Tests
{
    public static class AwaitablePipelineTestExtensions
    {
        public static void ProcessAndPrintResults<TInput, TOutput>(
            this IAwaitablePipelineRunner<TInput, TOutput> pipelineRunner,
            IEnumerable<TInput> items,
            PipelineTestBase pipelineTest)
        {
            // Start timer
            pipelineTest.StartTimer();

            // Process items
            var result = pipelineRunner.Process(items).ToArray();

            // Print elapsed time and result
            pipelineTest.StopTimerAndPrintResult(result);
        }

        public static void ProcessAndPrintResults<TInput, TOutput>(
            this (PipelineTestBase PipelineTest, IAwaitablePipelineRunner<TInput, TOutput> PipelineRunner) testAndRunner, 
            IEnumerable<TInput> items)
        {
            var (pipelineTest, pipelineRunner) = testAndRunner;

            // Start timer
            pipelineTest.StartTimer();

            // Process items
            var result = pipelineRunner.Process(items).ToArray();

            // Print elapsed time and result
            pipelineTest.StopTimerAndPrintResult(result);
        }
    }
}