﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Mongo.Repository.ExtensionMethods
{
    public static class TaskExtensions
    {
        public static Task<TReturn> Convert<T, TReturn>(this Task<T> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            var tcs = new TaskCompletionSource<TReturn>();
            task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith(t => { tcs.TrySetResult(AutoMapper.Mapper.Map<T, TReturn>(t.Result)); },
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => tcs.TrySetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            return tcs.Task;

        }

        public static Task<List<TReturn>> ConvertEach<T, TReturn>(this Task<List<T>> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            var tcs = new TaskCompletionSource<List<TReturn>>();
            task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith(t => { tcs.TrySetResult(t.Result.Select(AutoMapper.Mapper.Map<T, TReturn>).ToList()); },
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => tcs.TrySetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            return tcs.Task;

        }
        public static Task<IEnumerable<TReturn>> ConvertEach<T, TReturn>(this Task<IEnumerable<T>> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            var tcs = new TaskCompletionSource<IEnumerable<TReturn>>();
            task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith(t => { tcs.TrySetResult(t.Result.Select(AutoMapper.Mapper.Map<T, TReturn>).AsEnumerable()); },
                TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => tcs.TrySetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
            return tcs.Task;

        }
    }
}
