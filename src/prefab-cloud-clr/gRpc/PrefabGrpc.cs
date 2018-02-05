// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: proto/prefab.proto
#pragma warning disable 1591
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace Prefab {
  public static partial class RateLimitService
  {
    static readonly string __ServiceName = "prefab.RateLimitService";

    static readonly grpc::Marshaller<global::Prefab.LimitRequest> __Marshaller_LimitRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Prefab.LimitRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Prefab.LimitResponse> __Marshaller_LimitResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Prefab.LimitResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Prefab.LimitRequest, global::Prefab.LimitResponse> __Method_LimitCheck = new grpc::Method<global::Prefab.LimitRequest, global::Prefab.LimitResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "LimitCheck",
        __Marshaller_LimitRequest,
        __Marshaller_LimitResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Prefab.PrefabReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of RateLimitService</summary>
    public abstract partial class RateLimitServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Prefab.LimitResponse> LimitCheck(global::Prefab.LimitRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for RateLimitService</summary>
    public partial class RateLimitServiceClient : grpc::ClientBase<RateLimitServiceClient>
    {
      /// <summary>Creates a new client for RateLimitService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public RateLimitServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for RateLimitService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public RateLimitServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected RateLimitServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected RateLimitServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Prefab.LimitResponse LimitCheck(global::Prefab.LimitRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return LimitCheck(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Prefab.LimitResponse LimitCheck(global::Prefab.LimitRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_LimitCheck, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Prefab.LimitResponse> LimitCheckAsync(global::Prefab.LimitRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return LimitCheckAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Prefab.LimitResponse> LimitCheckAsync(global::Prefab.LimitRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_LimitCheck, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override RateLimitServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new RateLimitServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(RateLimitServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_LimitCheck, serviceImpl.LimitCheck).Build();
    }

  }
  public static partial class ConfigService
  {
    static readonly string __ServiceName = "prefab.ConfigService";

    static readonly grpc::Marshaller<global::Prefab.ConfigServicePointer> __Marshaller_ConfigServicePointer = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Prefab.ConfigServicePointer.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Prefab.ConfigDeltas> __Marshaller_ConfigDeltas = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Prefab.ConfigDeltas.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Prefab.UpsertRequest> __Marshaller_UpsertRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Prefab.UpsertRequest.Parser.ParseFrom);

    static readonly grpc::Method<global::Prefab.ConfigServicePointer, global::Prefab.ConfigDeltas> __Method_GetConfig = new grpc::Method<global::Prefab.ConfigServicePointer, global::Prefab.ConfigDeltas>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetConfig",
        __Marshaller_ConfigServicePointer,
        __Marshaller_ConfigDeltas);

    static readonly grpc::Method<global::Prefab.UpsertRequest, global::Prefab.ConfigServicePointer> __Method_Upsert = new grpc::Method<global::Prefab.UpsertRequest, global::Prefab.ConfigServicePointer>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Upsert",
        __Marshaller_UpsertRequest,
        __Marshaller_ConfigServicePointer);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Prefab.PrefabReflection.Descriptor.Services[1]; }
    }

    /// <summary>Base class for server-side implementations of ConfigService</summary>
    public abstract partial class ConfigServiceBase
    {
      public virtual global::System.Threading.Tasks.Task GetConfig(global::Prefab.ConfigServicePointer request, grpc::IServerStreamWriter<global::Prefab.ConfigDeltas> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Prefab.ConfigServicePointer> Upsert(global::Prefab.UpsertRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ConfigService</summary>
    public partial class ConfigServiceClient : grpc::ClientBase<ConfigServiceClient>
    {
      /// <summary>Creates a new client for ConfigService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ConfigServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ConfigService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ConfigServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ConfigServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ConfigServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::Prefab.ConfigDeltas> GetConfig(global::Prefab.ConfigServicePointer request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return GetConfig(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Prefab.ConfigDeltas> GetConfig(global::Prefab.ConfigServicePointer request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetConfig, null, options, request);
      }
      public virtual global::Prefab.ConfigServicePointer Upsert(global::Prefab.UpsertRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return Upsert(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Prefab.ConfigServicePointer Upsert(global::Prefab.UpsertRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Upsert, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Prefab.ConfigServicePointer> UpsertAsync(global::Prefab.UpsertRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return UpsertAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Prefab.ConfigServicePointer> UpsertAsync(global::Prefab.UpsertRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Upsert, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ConfigServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ConfigServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ConfigServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetConfig, serviceImpl.GetConfig)
          .AddMethod(__Method_Upsert, serviceImpl.Upsert).Build();
    }

  }
}
#endregion